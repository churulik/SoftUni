'use strict';

angular
    .module('issueTracker.projects', [
        'issueTracker.datePickerServices',
        'issueTracker.filterByDateService',
        'issueTracker.formatterDirective',
        'issueTracker.labels',
        'issueTracker.parserDirective',
        'issueTracker.projectsServices'
    ])

    .config(['$routeProvider', function ($routeProvider) {

        $routeProvider
            .when('/projects', {
                templateUrl: 'projects/list-all-projects.html',
                controller: 'ProjectsController'
            })
            .when('/projects/add', {
                templateUrl: 'projects/add-project.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id', {
                templateUrl: 'projects/project-by-id.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/edit', {
                templateUrl: 'projects/edit-project.html',
                controller: 'ProjectsController'
            })
            .when('/projects/:id/add-issue', {
                templateUrl: 'projects/add-issue.html',
                controller: 'ProjectsController'
            })
    }])

    .controller('ProjectsController', ['$scope', '$routeParams', '$location', '$route', 'accountServices', 'datePickerServices',
        'filterByDateService', 'notifyServices', 'projectsServices',
        function ($scope, $routeParams, $location, $route, accountServices, datePickerServices, filterByDateService, notifyServices, projectsServices) {

            var currentUser = accountServices.getCurrentUser(),
                projectId = $routeParams.id,
                assignee = {Assignee: {Username: currentUser}};

            $scope.filterByPriority = {};
            $scope.filterMyIssues = assignee;
            $scope.isAdmin = accountServices.isAdministrator();
            $scope.issueData = {};
            $scope.issueStatus = {};
            $scope.labels = [];
            $scope.orderIssues = 'DueDate';
            $scope.projectData = {};
            $scope.projectId = projectId;
            $scope.projectsServices = projectsServices;
            $scope.selectedProject = {};
            $scope.show = {all: false};
            $scope.statusClosed = false;
            $scope.statusInProgress = false;
            $scope.statusOpen = false;
            $scope.statusStoppedProgress = false;

            $scope.initAddIssue = function () {
                projectsServices.getProjectById(projectId).then(function (project) {
                    if (project.Id == projectId && project.Lead.Username !== currentUser && !$scope.isAdmin) {
                        return $location.path('/projects/' + projectId);
                    }

                    datePickerServices.datePicker($scope);

                    getAllUsers();

                    projectsServices.getAllProjects().then(function (projects) {
                        $scope.availableProjects = projects.filter(function (project) {
                            if (!$scope.isAdmin) {
                                return project.Lead.Username === currentUser;
                            } else {
                                return project;
                            }
                        });
                    });
                }, redirectIfProjectDoesNotExist);


                $scope.addIssue = function (issueData, project, date) {
                    issueData['ProjectId'] = project.Id;
                    issueData['DueDate'] = date;
                    projectsServices.addIssue(issueData, projectId);
                };
            };

            $scope.initAddProject = function () {
                getAllUsers();

                $scope.addProject = function (projectData) {
                    projectsServices.addProject(projectData);
                };
            };

            $scope.initEditProject = function () {
                projectsServices.getProjectById(projectId).then(function (project) {
                    if (project.Id == projectId && project.Lead.Username !== currentUser && !$scope.isAdmin) {
                        return $location.path('/projects/' + projectId);
                    }
                    
                    $scope.project = project;
                    getAllUsers();

                }, redirectIfProjectDoesNotExist);


                $scope.editProject = function (project) {
                    var projectData = {
                        Name: project.Name,
                        Description: project.Description,
                        LeadId: project.Lead.Id,
                        Labels: project.Labels,
                        Priorities: project.Priorities
                    };

                    projectsServices.editProject(projectData, projectId);
                };
            };

            $scope.initListAllProjects = function () {
                projectsServices.getAllProjects().then(function (projects) {
                    $scope.projects = projects;
                });
            };

            $scope.initProjectById = function () {
                projectsServices.getProjectById(projectId).then(function (project) {
                    if (project.Id == projectId && project.Lead.Username !== currentUser && !$scope.isAdmin) {
                        $location.path('/projects/' + projectId);
                    }
                    $scope.isProjectLeader = currentUser === project.Lead.Username;
                    $scope.project = project;

                }, redirectIfProjectDoesNotExist);

                projectsServices.getProjectIssues(projectId).then(function (issues) {
                    $scope.issues = issues;
                });

                $scope.filterIssuesByAssignee = function () {
                    if (!$scope.show.all) {
                        $scope.filterMyIssues = assignee;

                    } else {
                        $scope.filterMyIssues = '';

                    }
                };

                $scope.filterIssuesByDueDate = function (day) {
                    filterByDateService.filter($scope, day);
                };

                $scope.filterIssuesByStatus = function (status) {
                    function noFilter(statusesObj) {
                        for (var status in statusesObj) {
                            if (statusesObj[status]) {
                                return false;
                            }
                        }
                        return true;
                    }

                    return $scope.issueStatus[status.Status.Name] || noFilter($scope.issueStatus);
                };

                $scope.orderByIssues = function (parametar) {
                    $scope.orderIssues = parametar;
                }
            };

            function getAllUsers() {
                accountServices.getAllUsers().then(function (users) {
                    $scope.users = users;
                });
            }

            function redirectIfProjectDoesNotExist() {
                $location.path('/');
                notifyServices.showError('A project with this id does not exist');
            }
        }]);