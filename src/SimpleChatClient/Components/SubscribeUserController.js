angular.module('SimpleChat')
	.controller('SubscribeUserController', function($scope, SimpleChatSignalRService, notificationService){

		$scope.NickName = '';

		$scope.SubscribeUser = function(){
			SimpleChatSignalRService.SubscribeUser($scope.NickName);
		}
	});