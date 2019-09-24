<template>
  <label>
    <input type="radio" :checked="shouldBeChecked" :value="value" @change="updateInput">
    {{ label }}
  </label>
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