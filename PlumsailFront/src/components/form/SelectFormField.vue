<template>
    <div>
        <select 
            :class="`form-input ${valideClass}`" 
            v-bind="selectProps" 
            @input="onChange($event)"
        >
            <option
                v-for="option in options"
                :key="option.value"
                :disabled="option.disabled"
                :value="option.value"
            >
                {{option.label}}
            </option>
        </select>
        <span class="form-error-text">{{error}}</span>
    </div>
</template>

<script>
export default {
    props: {
        value: {
            required: true
        },
        options:{
            type: Array,
            required: true
        },
        error: String,
        accesskey: String,
        autofocus: String,
        disabled: String,
        form: String,
        multiple: String,
        name: String,
        required: String,
        size: String,
        tabindex: String,
    },
    methods: {
        onChange(e){
            this.$emit('input', e.target.value);
        }
    },
    computed: {
        valideClass() {
            return this.error ? 'form-error-input' : '';
        },
        selectProps(){
            return {
                ...this.$props,
                options: undefined,
                error: undefined
            };
        }
    }
}
</script>

<style scoped>
</style>