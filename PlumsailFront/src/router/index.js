import Vue from 'vue';
import VueRouter from 'vue-router';

import CreateObjectView from '@/views/CreateObjectView.vue';
import ListView from '@/views/ListView.vue';

import { routes } from '@/support';

Vue.use(VueRouter);

export function createRouter (store) {
    return new VueRouter({
        mode: 'history',
        routes : [
            {
                path: routes.start.path,
                name : routes.start.name,
                redirect: () => ({ name: [routes.createObject.name] })
            },
            {
                path: routes.createObject.path,
                name: routes.createObject.name,
                component :  CreateObjectView,
            },
            {
                path: routes.list.path,
                name: routes.list.name,
                component :  ListView,
                beforeEnter: async (_to, _from, next) => {
                    await store.dispatch("objects/GET");
                    next();
                }  
            }
        ]
    });
}