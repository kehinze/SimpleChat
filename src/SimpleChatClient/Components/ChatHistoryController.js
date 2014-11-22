angular.module('SimpleChat')
	.controller('ChatHistoryController', function($scope, notificationService){

		$scope.Chats = [];

		$scope.$on('ChatReceived', function(event, result){
			$scope.Chats.push(result);
			$scope.$apply();
		});	
	});