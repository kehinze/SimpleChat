angular.module('SimpleChat')
	.controller('UsersController', function($scope, SimpleChatApiService, notificationService){

		$scope.Users = [];

		$scope.$on('UserSubscribed', function(event, user){
			$scope.Users.push(user);
			$scope.$apply();
		});

		var init = function(){
			SimpleChatApiService.GetUsers()
				.success(onUsersReceived)
				.error(onError);
		}

		var onUsersReceived = function(users){
			$scope.Users = users;
		};

		var onError = function(result){
			notificationService.error(result.Message);
		};

		init();
	});