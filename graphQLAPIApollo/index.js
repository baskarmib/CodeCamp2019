const {ApolloServer} = require('apollo-server-express');
const express = require('express');
const queryurl = require('graphql-playground-middleware-express').default;
const fs = require('fs');
const  typeDefs = fs.readFileSync('./typeDefs.graphql','UTF-8');
const resolvers = require('./resolvers');

var app = express();
const server = new ApolloServer({typeDefs, resolvers});

server.applyMiddleware({app})
app.get('/',(req, res)=>res.end("Hello CodePaLOUsa"))
app.get('/playground',queryurl({endpoint:'/graphql'}))
app.listen(4000, () => console.log('Now browse to localhost:4000${server.graphqlPath}'));