<template>
    <div class="wrapper">
        <text-field 
            type="text" 
            label="text" 
            v-model="form.name"
            :error="errors.name"
        />
        <text-field 
            type="textarea" 
            label="url" 
            v-model="form.description"
            :error="errors.description"
        />
        <check-field
            label="Ваши увлечения"
            :error="errors.che"
        >
            <check-field-item 
                v-model="form.che"
                :error="errors.che"
                value="Привет"
                label="Привет"
            />
            <check-field-item 
                v-model="form.che"
                :error="errors.che"
                value="Привет2"
                label="Привет2"
            />
            <check-field-item 
                v-model="form.che"
                :error="errors.che"
                value="Привет3"
                label="Привет3"
            />
        </check-field>
        <check-field
            label="Ваши увлечения 2"
            :error="errors.radi"
        >
            <radio-field-item 
                v-model="form.radi"
                :error="errors.radi"
                value="Пока"
                label="Пока"
            />
            <radio-field-item 
                v-model="form.radi"
                :error="errors.radi"
                value="Пока2"
                label="Пока2"
            />
        </check-field>
    </div>
</template>

<script>
import TextField from '../components/form/TextFormField';
import CheckField from '../components/form/CheckFormField';
import CheckFieldItem from '../components/form/CheckFormFieldItem';
import RadioFieldItem from '../components/form/RadioFormFieldItem';

export default {
    components: {
        TextField,
        CheckFieldItem,
        RadioFieldItem,
        CheckField
    },
    data() {
        return {
            form: {
                name: '',
                description: '',
                che: [],
                radi: null
            },
            errors: {
                name: null,
                description: null,
                che: null,
                radi: null
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