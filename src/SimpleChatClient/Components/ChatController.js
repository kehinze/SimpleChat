angular.module('SimpleChat')
	.controller('ChatController', function($scope, SimpleChatSignalRService, notificationService){

		//temp for testing. . . 
		$scope.IsUserSelected = false;

		$scope.SelectedUser = {
			Id: '',
			NickName: ''
		};

		$scope.$on('UserSelected', function(event, user){
			$scope.IsUserSelected = true;
			$scope.SelectedUser = user;
		});
	});