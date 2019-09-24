import {
    request,
    defaultVuex
} from '../support';

export const objects = {
    namespaced: true,
    state:{
        ...defaultVuex.state,
        data : [],
    },
    getters:{
        ...defaultVuex.getters,
        "DATA"   : state => state.data
    },
    mutations:{
        ...defaultVuex.mutations,
        "SET": (state, objects) => {
            state.data = [
                ...objects
            ];
        },
        "CLEAR": (state) => {
            defaultVuex.clear(state);
            state.objects = [];
        }
    },
    actions:{
        ...defaultVuex.actions,
        "GET" : async ({commit})=>{
            commit(defaultVuex.mutationsNames.startLoading);
            try {
                const {data} = await request(process.env.VUE_APP_OBJECTS, 'GET');
                commit("SET", data);
                commit(defaultVuex.mutationsNames.finishLoading);
            }
            catch (error) {
                if(!error.response || error.response.status !== 400){
                    commit(defaultVuex.mutationsNames.setError);
                }
                else
                {
                    commit(defaultVuex.mutationsNames.setError, error.response.data);
                }
                commit(defaultVuex.mutationsNames.finishLoading);
            }
        },
        "SAVE" : async ({commit}, form)=>{
            commit(defaultVuex.mutationsNames.startLoading);
            // try {
                await request(process.env.VUE_APP_OBJECTS, 'POST', form);
                commit(defaultVuex.mutationsNames.finishLoading);
            // }
            // catch (error) {
            //     if(!error.response || error.response.status !== 400){
            //         commit(defaultVuex.mutationsNames.setError);
            //     }
            //     else
            //     {
            //         commit(defaultVuex.mutationsNames.setError, error.response.data);
            //     }
            //     commit(defaultVuex.mutationsNames.finishLoading);
            // }
        },
    }
};
