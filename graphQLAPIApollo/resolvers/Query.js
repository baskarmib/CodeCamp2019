const dataRetrieval= require("../dataRetrieval.js");

module.exports = {
    
        hello(){
          return "Hello CodePaLOUsa 2019";
        },
        allemployees() {
            return dataRetrieval.getAllEmployeeDetails();
        },

        employee(parent, args) {
            return dataRetrieval.getEmployeeDetails(args);
        },

        allprojects() {
            return dataRetrieval.getAllProjects();
        },

        project(parent, args) {
            return dataRetrieval.getProjectDetailsById(args.projectId);
        }
   
}