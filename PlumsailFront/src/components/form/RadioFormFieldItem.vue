<template>
  <div class="wrapper">
    <label class="title radio" :for="id">
      <input 
        :class="`input ${valideClass}`" 
        :id="id" 
        type="radio" 
        :checked="shouldBeChecked" 
        :value="value" 
        @change="updateInput"
      >
      <div class="radio__text">{{ label }}</div>
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
      default: ""
    },
    label: {
      type: String,
      required: true
    },
    error: String
  },
  data() {
      return {
        _id: null
      }
  },
  computed: {
    shouldBeChecked() {
      return this.modelValue == this.value
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
    updateInput() {
      this.$emit('change', this.value)
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

.radio input {
	position: absolute;
	z-index: -1;
	opacity: 0;
	margin: 10px 0 0 7px;
}
.radio__text {
	position: relative;
	padding: 0 0 0 35px;
	cursor: pointer;
}
.radio__text:before {
	content: '';
	position: absolute;
	top: -3px;
	left: 0;
	width: 22px;
	height: 22px;
	border: 1px solid #CDD1DA;
	border-radius: 50%;
	background: #FFF;
}
.radio__text:after {
	content: '';
	position: absolute;
	top: 1px;
	left: 4px;
	width: 16px;
	height: 16px;
	border-radius: 50%;
	background: #55aed1;
	opacity: 0;
	transition: .2s;
}
.radio input:checked + .radio__text:after {
	opacity: 1;
}
.radio input.error-input + .radio__text:before {
	box-shadow: 0 0 0 3px #e97272cc;
}
</style>