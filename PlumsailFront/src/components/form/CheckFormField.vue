<template>
    <div>
        <label class="form-title">{{label}}</label>
        <span class="form-error-text">{{error}}</span>
        <div>
            <component
                v-for="value in values"
                :key="value.value"
                :label="value.label"
                :value="value.value"
                :is="component"
                v-model="model"
            />
        </div>
    </div>
</template>

<script>
import CheckFieldItem from './CheckFormFieldItem';
import RadioFieldItem from './RadioFormFieldItem';

export default {
    model: {
        prop: 'modelValue',
        event: 'change'
    },
    props: {
        label: {
            type: String,
            required: true
        },
        type: {
            type: String,
            required: true,
            validator: function(value) {
                return ['checkbox', 'radio'].includes(value);
            }
        },
        values: {
            type: Array,
            required: true
        },
        modelValue: {
            default: null
        },
        error: String,
    },
    computed: {
        component(){
            if(this.type === 'checkbox'){
                return CheckFieldItem;
            }

            return RadioFieldItem;
        },
        model: {
            get(){
                return this.modelValue
            },
            set(value){
                this.$emit('change', value);
            }
        }
    }
}
</script>