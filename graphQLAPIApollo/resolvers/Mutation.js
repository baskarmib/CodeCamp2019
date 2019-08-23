const dataRetrieval= require("../dataRetrieval.js");

module.exports={

    updateProjectStatus(parent, args){
        console.log(dataRetrieval.sampleData);
        let projectdetails = dataRetrieval.sampleData.Project.filter(x=>x.projectId==args.projectId)[0];
        if(projectdetails && args.projectStatus)
        {
            projectdetails.projectStatus= args.projectStatus
        }
        return projectdetails;
    }
}