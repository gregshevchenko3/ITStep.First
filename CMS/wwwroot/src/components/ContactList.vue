<template>
    <v-card elevation="12">
        <v-card-title class="cardtitle"> {{title}} </v-card-title>
        <v-card-actions class="cardtitle">
            <v-tooltip bottom>
                <template v-slot:activator="{ on, attrs }">
                    <v-btn icon outlined tile v-bind="attrs" v-on="on" :disabled="selected == null"><v-icon>fas fa-edit</v-icon></v-btn>
                </template>
                <span> Редагувати виділений контакт </span>
            </v-tooltip>
            <v-tooltip bottom>
                <template v-slot:activator="{ on, attrs }">
                    <v-btn icon outlined tile v-bind="attrs" v-on="on"  :disabled="selected == null"><v-icon>fas fa-minus</v-icon></v-btn>
                </template>
                <span> Видалити виділений контакт </span>
            </v-tooltip>
            <v-tooltip bottom>
                <template v-slot:activator="{ on, attrs }">
                    <v-btn icon outlined tile v-bind="attrs" v-on="on"><v-icon>fas fa-plus</v-icon></v-btn>
                </template>
                <span> Добавити новий контакт </span>
            </v-tooltip>
        </v-card-actions>
        <v-list dense class="d-flex-col align-end py-2" nav>
            <v-list-item-group active-class="activeItem" v-model="selected">
                <v-list-item v-for="item in contacts" :key="item.title">
                    <template>
                        <v-list-item-icon class="d-flex py-0">
                            <v-icon> {{item.icon}} </v-icon>
                        </v-list-item-icon>
                        <v-list-item-content cols="8" class="d-flex align-end">
                            <v-list-item-title>{{item.url}}</v-list-item-title>
                        </v-list-item-content>
                    </template>
                </v-list-item>
            </v-list-item-group>
        </v-list>
    </v-card>
</template>

<script>
    export default {
        name: "ContactList",
        data() {
            return {
                selected: null
            }
        },
        props: {
            title: String,
            contacts: Array
        }
    }
</script>