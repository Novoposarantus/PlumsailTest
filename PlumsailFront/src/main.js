import Vue from 'vue'
import App from './App.vue'
import { sync } from 'vuex-router-sync';

import {createStore} from './store';
import {createRouter} from './router';

import '../public/styles.css';

const store = createStore();
const router = createRouter(store);

sync(store,router)

new Vue({
  el: '#app',
  store,
  router,
  render: h => h(App)
});
