<template>
    <div>
        <label class="form-title" :for="id">{{label}}</label>
        <component
            :is="component"
            v-bind="$props"
            :class="`input ${valideClass}`" 
            :id="id"
            @input="handler($event)"
        />
        <span class="form-error-text">{{error}}</span>
    </div>
</template>

<script>

const textareaType = 'textarea';

export default {
    props: {
        value: {
            type: String,
            required: true
        },
        label: {
            type: String,
            required: true
        },
        type: {
            type: String,
            default: 'text'
        },
        title: String,
        error: String,
        accept: String,
        accesskey: String,
        autofocus: String,
        cols: String,
        disabled: String,
        form: String,
        maxlength: String,
        name: String,
        placeholder: String,
        readonly: String,
        required: String,
        rows: String,
        tabindex: String,
        wrap: String,
        autocomplete: String,
        alt: String,
        formaction: String,
        formenctype: String,
        formmethod: String,
        formtarget: String,
        list: String,
        border: String,
        formnovalidate: String,
        max: String,
        min: String,
        multiple: String,
        pattern: String,
        size: String,
        src: String,
        step: String,
        tabindex: String,
    },
    data() {
        return {
            _id: null
        }
    },
    computed: {
        component() {
            if(this.type === textareaType) {
                return 'textarea';
            }

            return 'input';
        },
        id() {
            if (!this._id) {
                this._id = `f${(~~(Math.random()*1e8)).toString(16)}`;
            }
            return this._id;
        },
        valideClass() {
            return this.error ? 'error-input' : '';
        }
    },
    methods: {
        handler(e) {
            this.$emit('input', e.target.value);
        }
    }
}
</script>

<style scoped>

.input {
    display: block;
    width: 100%;
    max-width: 100%;
    font-size: 18px;
    border: 1px solid #cccccc;
    border-radius: 3px;
    -webkit-border-radius: 3px;
    -moz-border-radius: 3px;
    -khtml-border-radius: 3px;
    background: #ffffff !important;
    outline: none;
    padding: 3px 5px;
}


.error-input {
    border: 1px solid #e97272;
}


.input::-webkit-scrollbar {
    width: 10px;
    background-color: #ffffff00;
    cursor: default;
}

.input::-webkit-scrollbar-thumb {
    background-color: #363636cc;
    border-radius: 2px;
}

.input::-webkit-scrollbar-track {
    box-shadow: inset 0 0 6px #9facb9;
    background-color: #f0f8ff;
    border-radius: 2px;
}
</style>