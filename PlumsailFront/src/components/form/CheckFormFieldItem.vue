<template>
    <div>
        <label class="title" :for="id">
            <input 
                :class="`input ${valideClass}`" 
                :id="id" 
                type="checkbox" 
                :checked="shouldBeChecked" 
                :value="value" 
                @change="updateInput"
            >
            {{title}}
        </label>
    </div>
</template>

<script>
export default {
  model: {
    prop: 'modelValue',
    event: 'change'
  },
  props: {
    value: {
        type: String,
    },
    modelValue: {
        default: false
    },
    title: {
        type: String,
        required: true
    },
    trueValue: {
        default: true
    },
    falseValue: {
        default: false
    }
  },
  computed: {
    shouldBeChecked() {
        if (this.modelValue instanceof Array) {
            return this.modelValue.includes(this.value)
        }
        return this.modelValue === this.trueValue
    }
  },
  methods: {
    updateInput(event) {
        let isChecked = event.target.checked
        let newValue = [...this.modelValue]

        if (isChecked) {
            newValue.push(this.value)
        } else {
            newValue.splice(newValue.indexOf(this.value), 1)
        }

        this.$emit('change', newValue)
    }
  }
}
</script>

<style scoped>
.title{
    font-size: 18px;
    max-width: 100%;
    padding-left: 1px;
}

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

.error-input{
    border: 1px solid #e97272;
}

.error-text {
    display: block;
    color: #e97272;
    font-size: 12px;
    height: 14px;
    max-width: 100%;
    padding-left: 1px;
}

</style>