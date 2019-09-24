<template>
    <div class="wrapper">
        <form @submit.prevent="submit">
            <div class="error error-text-color" v-if="saveError">
                {{saveError}}
            </div>
            <text-field
                label="Имя" 
                v-model="form.name"
                :error="errors.name"
            />
            <text-field 
                type="date" 
                label="Дата рождения" 
                v-model="form.birthdate"
                :error="errors.birthdate"
            />
            <text-field 
                type="textarea" 
                label="О себе"
                rows="4"
                v-model="form.bio"
                :error="errors.bio"
            />
            <check-field
                label="Ваши увлечения"
                :error="errors.hobby"
            >
                <check-field-item 
                    v-model="form.hobby"
                    :error="errors.hobby"
                    value="Спорт"
                    label="Спорт"
                />
                <check-field-item 
                    v-model="form.hobby"
                    :error="errors.hobby"
                    value="Видео игры"
                    label="Видео игры"
                />
                <check-field-item 
                    v-model="form.hobby"
                    :error="errors.hobby"
                    value="Кино"
                    label="Кино"
                />
                <check-field-item 
                    v-model="form.hobby"
                    :error="errors.hobby"
                    value="Театр"
                    label="Театр"
                />
                <check-field-item 
                    v-model="form.hobby"
                    :error="errors.hobby"
                    value="Книги"
                    label="Книги"
                />
                <check-field-item 
                    v-model="form.hobby"
                    :error="errors.hobby"
                    value="Прогулки"
                    label="Прогулки"
                />
            </check-field>
            <check-field
                label="Пол"
                :error="errors.sex"
            >
                <radio-field-item 
                    v-model="form.sex"
                    :error="errors.sex"
                    value="Мужчина"
                    label="Мужчина"
                />
                <radio-field-item 
                    v-model="form.sex"
                    :error="errors.sex"
                    value="Женщина"
                    label="Женщина"
                />
            </check-field>
            <div class="actions">
                <button class="submit-button">Отправить</button>
            </div>
        </form>
    </div>
</template>

<script>
import TextField from '../components/form/TextFormField';
import CheckField from '../components/form/CheckFormField';
import CheckFieldItem from '../components/form/CheckFormFieldItem';
import RadioFieldItem from '../components/form/RadioFormFieldItem';

import { mapActions, mapGetters } from 'vuex';
import { routes, defaultVuex } from '../support';

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
                birthdate: '',
                bio: '',
                hobby: [],
                sex: null
            },
            errors: {
                name: null,
                birthdate: null,
                bio: null,
                hobby: null,
                sex: null
            }
        }
    },
    computed: {
        ...mapGetters({
            saveError: defaultVuex.globalGettersNames('objects').error
        }),
        formNotValid(){
            return Object.values(this.errors).some(value => !!value);
        }
    },
    methods: {
        ...mapActions({
            send: 'objects/SAVE'
        }),
        submit: async function() {
            this.validate();
            if(this.formNotValid){
                return;
            }
            await this.send(this.form);
            if(this.saveError){
                return;
            }
            this.$router.push({name: routes.list.name});
        },
        validate(){
            if (!this.form.name) {
                this.errors.name = 'Введите имя';
            }

            if (!this.form.birthdate) {
                this.errors.birthdate = 'Введите дату рождения';
            }
            
            if (!this.form.bio) {
                this.errors.bio = 'Опишите себя';
            }

            if (!this.form.hobby || this.form.hobby.length == 0) {
                this.errors.hobby = 'Выберите хотя бы один вариант';
            }

            if (!this.form.sex) {
                this.errors.sex = 'Выберите пол';
            }
        },
        clearErrors(){
            for(var key in this.errors){
                this.$set(this.errors, key, null);
            }
        }
    },
    watch: {
        form: {
            handler(){
                this.clearErrors();
            },
            deep: true
        }
    }
}
</script>

<style scoped>
.wrapper {
    width: 300px;
    margin: 0 auto;
}

.submit-button {
  background-color: #55aed1;
  border: none;
  color: white;
  padding: 10px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  border-radius: 10px;
  transition: all .3s linear;
  cursor: pointer;
}

.submit-button:hover {
  background-color: #4fa0c0;
}

.actions{
    text-align: center;
}

.error {
    margin-bottom: 5px;
    font-size: 12px;
}
</style>