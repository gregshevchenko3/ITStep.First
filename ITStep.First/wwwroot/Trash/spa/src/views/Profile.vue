<template>
    <v-container fluid>
        <v-row>
            <v-col cols="3">
                <v-card elevation="12">
                    <v-img :src="ProfileImageUrl"
                           class="grey darken-4"
                           height="250"
                           width="250"></v-img>
                    <v-card-title>
                        <v-tooltip bottom>
                            <template v-slot:activator="{ on, attrs }">
                                <v-btn icon
                                       outlined
                                       tile
                                       v-bind="attrs"
                                       v-on="on">
                                    <v-icon>fas fa-user-edit</v-icon>
                                </v-btn>
                            </template>
                            <span> Змінити зображення профілю </span>
                        </v-tooltip>
                    </v-card-title>
                </v-card>
                <v-card elevation="12" class="mt-4">
                    <v-tooltip bottom>
                        <template v-slot:activator="{ on, attrs }">
                            <v-btn outlined tile v-bind="attrs" v-on="on" block> Зберегти </v-btn>
                        </template>
                        <span> Зберегти всі зміни </span>
                    </v-tooltip>
                </v-card>
            </v-col>
            <v-col cols="8">
                <v-card elevation="12">
                    <v-card-title>Назва блогу</v-card-title>
                    <v-textarea outlined
                                rows="1"
                                dense
                                auto-grow
                                :value="BlogTitle"></v-textarea>
                </v-card>
           <!-- <contact-list class="mt-2" title="Контакти" v-bind:contacts="Contacts" /> -->
                <v-card elevation="12" class="mt-2">
                    <v-card-title>Сторінка "Про себе"</v-card-title>
                    <quill-editor v-model="AboutContent" class="quill-editor"/>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    // import ContactList from "../components/ContactList.vue"

    import 'quill/dist/quill.core.css' // import styles
    import 'quill/dist/quill.snow.css' // for snow theme
    import 'quill/dist/quill.bubble.css' // for bubble theme

    import { quillEditor } from 'vue-quill-editor'
    export default {
        computed: {
            BlogTitle: {
                get: function () {
                    return this.$store.state.Title
                },
                set: function (newTitle) {
                    this.$store.dispatch('setTitle', newTitle);
                }
            },
            ProfileImageUrl() {
                return this.$store.state.ProfileImageUrl
            },
            AboutContent: {
                get: function () {
                    return this.$store.state.About
                },
                set: function (newAboutContent) {
                    this.$store.dispatch('setAbout', newAboutContent);
                }
            }
        },
        mounted(){
            this.fetch();
        },
        methods: {
            fetch() {
                this.$store.dispatch('fetchTitle');
                this.$store.dispatch('fetchAbout');
                this.$store.dispatch('fetchProfileImageUrl');
            }
        },
        components: {
           // 'contact-list': ContactList,
            'quill-editor': quillEditor
        }
    }
</script>
<style>
    .bordered {
        border: 1px solid red;
    }
    .social-icon{
        width: 3.5em;
    }
    .cardtitle{
        background-color: ghostwhite
    }
    .activeItem {
        background-color: lightgray
    }
    .v-btn:hover, .v-list-item:hover {
        background-color: gray
    }
    .title-custom {
        padding-top: 1.5em;
        margin-bottom: 0.5em;
    }
    .ql-container {
        min-height: inherit;
    }
    .quill-editor {
        min-height: 5em;
    }
</style>
    