import Vue from 'vue'
import Vuex from 'vuex'
import SocialStore from './SocialStore.js'
import { APIURL } from './parameters.js'

Vue.use(Vuex)

export default new Vuex.Store({
    state: () => {
        return {
            Title: "",
            About: "",
            ProfileImageUrl: "https://retailx.com/wp-content/uploads/2019/12/iStock-476085198-300x300.jpg"
        }
    },
    mutations: {
        setTitle(state = {}, title = '') {
            state.Title = title;
        },
        setAbout(state = {}, about = '') {
            state.About = about;
        },
        setProfileImageUrl(state = {}, profileImageUrl) {
            state.ProfileImageUrl = profileImageUrl;
        }
    },
    actions: {
        fetchTitle({ commit }) {
            console.log(`${APIURL}strings/title`);
            fetch(`${APIURL}strings/title`)
                .then(response => response.json())
                .then(data => {
                    commit('setTitle', data.title);
                });
        },
        fetchAbout({ commit }) {
            fetch(`${APIURL}posts/about`)
                .then(response => response.json())
                .then(data => {
                    commit('setAbout', data.content);
                });
        },
        fetchProfileImageUrl({ commit }) {
            fetch(`${APIURL}images/profile`)
                .then(response => response.json())
                .then(data => {
                    commit('setAbout', data.url);
                });
        }
    },
    modules: {
        Social: SocialStore
    }
})
