<template>
    <div class="wrapper">
        <text-form-field 
            type="text" 
            label="text" 
            v-model="form.name"
            :error="errors.name"
        />
        <text-form-field 
            type="textarea" 
            label="url" 
            v-model="form.name"
            :error="errors.name"
        />
        <text-form-field 
            type="text" 
            label="text" 
            v-model="form.name"
            :error="errors.name"
        />
        <text-form-field 
            type="textarea" 
            label="url" 
            v-model="form.name"
            :error="errors.name"
        />
        <text-form-field 
            type="text" 
            label="text" 
            v-model="form.name"
            :error="errors.name"
        />
    </div>
</template>

<script>
import TextFormField from '../components/form/TextFormField';

export default {
    components: {
        TextFormField
    },
    data() {
        return {
            form: {
                name: ''
            },
            errors: {
                name: null
            }
        }
    }
}
</script>

<style scoped>
.wrapper {
    width: 300px;
    margin: 0 auto;
}
</style>