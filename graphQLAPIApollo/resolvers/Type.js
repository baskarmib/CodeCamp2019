const dataRetrieval= require("../dataRetrieval.js");
module.exports={
    Employee:{
        empId(parent, args) {
            return parent.empId;
        },

        firstName(parent, args) {
            return parent.firstName;
        },

        lastName(parent, args) {
            return parent.lastName;
        },

        workingprojects(parent) {
            return dataRetrieval.getProjectDetails(parent.workingprojects);
        }
    },
    Project:{
        projectId(parent, args) {
            return parent.projectId;
        },

        projectName(parent, args) {
            return parent.projectName;
        },

        projectDescription(parent, args) {
            return parent.projectDescription;
        },

        projectStatus(parent,args){
            return parent.projectStatus;
        },

        employees(parent) {
            return dataRetrieval.getEmployeesByProject(parent.projectId);
        }
    }
}