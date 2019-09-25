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
    },
    data() {
        return {
            id: `f${(~~(Math.random()*1e8)).toString(16)}`
        }
    },
    computed: {
        component() {
            if(this.type === textareaType) {
                return 'textarea';
            }

            return 'input';
        },
        valideClass() {
            return this.error ? 'form-error-input' : '';
        },
        textProps(){
            return {
                ...this.$props,
                label: undefined,
                error: undefined
            }
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

.input::-webkit-scrollbar-thumb {
    border-radius: 2px;
}

.input::-webkit-scrollbar-track {
    border-radius: 2px;
}
</style>