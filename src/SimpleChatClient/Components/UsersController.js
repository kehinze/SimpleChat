angular.module('SimpleChat')
	.controller('UsersController', function($scope, SimpleChatSignalRService, notificationService){

		$scope.Users = [];

		$scope.$on('UsersUpdated', function(event, result){
			$scope.Users = result.Users;
		});

		var init = function(){
			if($scope.Users.length == 0){
				SimpleChatApiService.GetUsers()
				.success(onUsersReceived)
				.error(onError);
			}
		}

		var onUsersReceived = function(user){
			$scope.Users = users;
		};

		var onError = function(result){
			notificationService.error(result.Message);
		};
	});