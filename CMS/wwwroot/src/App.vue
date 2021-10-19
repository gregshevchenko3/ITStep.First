<template>
    <v-app>
        <v-navigation-drawer permanent app>
            <v-divider></v-divider>
            <v-list dense
                    nav>
                <v-list-item v-for="item in items"
                                :to="item.route"
                                :key="item.title"
                                dense>
                    <v-list-item-icon>
                        <v-icon>{{ item.icon }}</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>{{ item.title }}</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
        </v-navigation-drawer>
        <v-app-bar app dark> </v-app-bar>
        <v-main>
            <router-view/>
        </v-main>
    </v-app>
</template>

<script>
    export default {
        data() {
            return {
                items: [
                    { title: 'Dashboard', icon: 'mdi-view-dashboard', route: '/'},
                    { title: 'Profile', icon: 'mdi-account', route: '/profile' },
                ],
                right: null,
            }
        },
    }
</script>
