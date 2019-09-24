<template>
    <div>
        <label class="form-title" :for="id">{{label}}</label>
        <component
            :is="component"
            v-bind="$props"
            :class="`form-input ${valideClass}`" 
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
            return this.error ? 'form-error-input' : '';
        }
    },
    methods: {
        handler(e) {
            this.$emit('input', e.target.value);
        }
    }
}
</script>