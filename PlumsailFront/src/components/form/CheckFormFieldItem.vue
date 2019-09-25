<template>
    <div class="wrapper">
        <label class="title checkbox" :for="id">
            <input 
                class="input" 
                :id="id" 
                type="checkbox" 
                :checked="shouldBeChecked" 
                :value="value" 
                @change="updateInput"
            >
            <div class="checkbox-text">{{label}}</div>
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
    label: {
        type: String,
        required: true
    }
  },
  data() {
      return {
        id: `f${(~~(Math.random()*1e8)).toString(16)}`
      }
  },
  computed: {
    shouldBeChecked() {
        return this.modelValue.includes(this.value)
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
.wrapper {
    padding: 7px 0;
}

.title {
    font-size: 16px;
}

.checkbox input {
	position: absolute;
	z-index: -1;
	opacity: 0;
	margin: 10px 0 0 20px;
}

.checkbox-text {
	position: relative;
	padding: 0 0 0 60px;
	cursor: pointer;
}

.checkbox-text:before {
	content: '';
	position: absolute;
	top: -4px;
	left: 0;
	width: 50px;
	height: 26px;
	border-radius: 13px;
	background: #CDD1DA;
	transition: .2s;
}

.checkbox-text:after {
	content: '';
	position: absolute;
	top: -2px;
	left: 2px;
	width: 22px;
	height: 22px;
	border-radius: 10px;
	background: #FFF;
	transition: .2s;
}

.checkbox input:checked + .checkbox-text:before {
	background: #55aed1;
}

.checkbox input:checked + .checkbox-text:after {
	left: 26px;
}
</style>