import Vue from 'vue'
import { APIURL } from './parameters.js'

export default {
    state: () => {
        return {
            SocialsEnum: [],
            Contacts: []
        }
    },
    mutations: {
        setSocialsEnum(state = {}, enSocials = []) {
            state.SocialsEnum = enSocials;
        },
        setContact(state = {}, { id = 0, item = {}}) {
            Vue.set(state.Contacts, id, item)
        },
        setContacts(state = {}, Contacts = []) {
            state.Contacts = Contacts;
        }
    },
    actions: {
        fetchSocialsEnum({ commit }) {
            fetch(`${APIURL}constants/socials`)
                .then(response => response.json())
                .then(data => {
                    commit('setSocialsEnum', data.enum);
                });
        },
        fetchContact({ commit }, id) {
            fetch(`${APIURL}contact/${id}`)
                .then(response => response.json())
                .then(data => {
                    let contact = data.contact;
                    commit('setContact', { id, contact });
                });
        },
        fetchContacts({ commit }) {
            fetch(`${APIURL}contact/all`)
                .then(response => response.json())
                .then(data => {
                    commit('setContacts', data.allContacts);
                });
        }
    }
}