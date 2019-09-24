import Vue from 'vue';
import Vuex from 'vuex';
import {objects} from './objects';

import {
    defaultVuex
} from '@/support';

Vue.use(Vuex);

const modules = {
    objects
}

export function createStore() {
    return new Vuex.Store({
        modules,
        getters:{
            "IS_LOADING" : (state) => {
                for(let moduleName in modules){
                    if(state[moduleName][defaultVuex.stateNames.isLoading]){
                        return true;
                    }
                }
                return false;
            }
        },
        actions:{
            "CLEAR_STORE" : ({commit}) => {
                for(let moduleName in modules){
                    commit(`${moduleName}/${defaultVuex.mutationsNames.clear}`);
                }
            }
        }
    });
}