const Query = require('./Query')
const Type = require('./Type')
const Mutation = require('./Mutation');

const resolvers = {
  Query,  
  Mutation,
  ...Type
}

module.exports = resolvers

