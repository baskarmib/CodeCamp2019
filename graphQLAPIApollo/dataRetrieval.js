const fs = require('fs');

let rawdata = fs.readFileSync('./data.json');
let sampleData = JSON.parse(rawdata);

const getEmployeeDetails = function(args) 
{
  console.log("Get Specific Employee Details");  
  console.log(args.empId);
  if (args.empId) 
  {
    console.log(args.empId) ;
    var employeeId = args.empId;
    return sampleData.Employee.filter(x=>x.empId == employeeId)[0];
  }  
}

const getAllEmployeeDetails = function(args) 
{
   return sampleData.Employee;  
}

const getAllProjects = function(args)
{
    return sampleData.Project;
}

const getProjectDetails = function(args)
{
  let projectdetails = new Array();
  if(args.length && args.length > 1)
  {
    console.log(args);    
    args.forEach(element => {
        projectdetails.push(sampleData.Project.filter(x=>x.projectId == element)[0]);
      });
   
  } 
  else if (args) 
  {
    console.log(args) ;
    var projectId = args;
    projectdetails.push(sampleData.Project.filter(x=>x.projectId == projectId)[0]);
  } 
  return projectdetails;
}


const getProjectDetailsById = function(args)
{
  if (args) 
  {
    console.log(args) ;
    var projectId = args;
    return sampleData.Project.filter(x=>x.projectId == projectId)[0];
  }   
}

const getEmployeesByProject = function(args)
{
    let employee = new Array();
    sampleData.Employee.forEach(element => {
        let workingprojects = element.workingprojects;
        if(element.workingprojects.filter(x=>x == args).length > 0)
        {
            employee.push(element);
        }
      });
    return employee;

}

module.exports ={
    getEmployeeDetails:getEmployeeDetails,
    getAllEmployeeDetails:getAllEmployeeDetails,
    getAllProjects : getAllProjects,
    getProjectDetails : getProjectDetails,
    getEmployeesByProject :getEmployeesByProject,
    getProjectDetailsById:getProjectDetailsById,
    sampleData : sampleData
}