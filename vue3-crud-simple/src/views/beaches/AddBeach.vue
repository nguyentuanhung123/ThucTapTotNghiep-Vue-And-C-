<script setup>
import axios from 'axios';
import { reactive } from 'vue';
import { useRouter } from 'vue-router';

let newBeach = reactive({
    beachName: "",
    place: "",
    imageUrl: ""
})

const router = useRouter();

const addBeach = () => {
    axios.post("http://localhost:5138/Beach", newBeach)
        .then(() => {
            router.push("/");
        })
}

</script>

<template>
    <div class="container mt-4">
        <form @submit.prevent="addBeach">
            <legend>Add A New Item</legend>
            <div class="mb-3">
                <label for="txtBeachName" class="form-label">Beach Name</label>
                <input 
                    type="text" 
                    class="form-control" 
                    id="txtBeachName" 
                    aria-describedby="emailHelp"
                    v-model="newBeach.beachName">
            </div>
            <div class="mb-3">
                <label for="txtLocation" class="form-label">Location</label>
                <input 
                    type="text" 
                    class="form-control" 
                    id="txtLocation" 
                    aria-describedby="emailHelp"
                    v-model="newBeach.place">
            </div>
            <div class="mb-3">
                <label for="txtImageUrl" class="form-label">ImageUrl</label>
                <input 
                    type="text" 
                    class="form-control" 
                    id="txtImageUrl" 
                    aria-describedby="emailHelp"
                    v-model="newBeach.imageUrl">
            </div>
            <button type="submit" class="btn btn-primary">Add</button>
        </form>
    </div>
</template>
