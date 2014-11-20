angular.module('SimpleChat')
	.controller('SubscribeUserController', function($scope, SimpleChatSignalRService, notificationService, SimpleChatService){

		$scope.NickName = '';

		$scope.SubscribeUser = function(){
			SimpleChatService.SetNickName($scope.NickName);
			SimpleChatSignalRService.SubscribeUser($scope.NickName);
		}
	});