<template>
  <v-container fluid grid-list-md>
    <v-layout row wrap>
      <v-flex xs6>
        <v-textarea
          name="protoTextArea"
          label="Default style"
          v-model="payloadStr"
          hint="Hint text"
         
        ></v-textarea>
      </v-flex>
      <v-btn color="blue" v-on:click="sendPayload">Success</v-btn>

      <v-flex xs6>
        <v-textarea
          name="tokenArea"
          label="Default style"
          v-bind:value="token"
        ></v-textarea>
      </v-flex>    

    </v-layout>
  </v-container>
</template>

<script>
import axios from 'axios'

export default {
  name: "LoginPrototype",
  data () {
    return {
      payloadStr: "{\"email\": \"julianpoyo+22@gmail.com\"," 
                    + "\"signature\": \"4T5Csu2U9OozqN66Us+pEc5ODcBwPs1ldaq2fmBqtfo=\","
                    + "\"ssoUserId\": \"0743cd2c-fec3-4b79-a5b6-a6c52a752c71\","
                    + "\"timestamp\": \"1552766624957\"}",
      token: ""
    }
    
  },

  methods: {
      sendPayload() {
          // Make sure its valid JSON object by attempting serialize
          // then send to server with axios command.
          console.log("Sending payload...");
          let tempStr = this.payloadStr.split("\n").join("");
          console.log(this.payloadStr);
          try {
              
              
              let temp = JSON.parse(tempStr);
              temp['headers']  = {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
              }
              const url = "http://localhost:59364/api/Login";
              axios.post(url, temp)
                   .then(response => {
                       this.token = response.data["redirectURL"]
                       console.log("Session Storage.token = " + sessionStorage.SITToken)
                   })
                   .catch(err => console.log("There was error. " + err.response));
              
            }
            catch(e) {
                console.log("Format Error");
            }
      }
  },
  

}
</script>


