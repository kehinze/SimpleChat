angular.module('SimpleChat')
	.factory('SimpleChatSignalRService', function($rootScope, Hub, simpleChatSignalrUrl){

		var hub = new Hub('ChatHub', {
	        listeners:{
	            'RaiseEvent': function (result) {
	                $rootScope.$broadcast(result.Type, result.Body);
	            }
	        },
	        methods: ['SubscribeUser'],
	        queryParams:{
	            'token': 'exampletoken'
	        },
	        rootPath: simpleChatSignalrUrl,
	        errorHandler: function(error){
	            console.error(error);
	        },
	    });

		var subscribeUser = function (nickName) {
		    hub.SubscribeUser(nickName); 
   		};		   

     	return {
     		SubscribeUser: function(nickName){
				return subscribeUser(nickName);
     		},
     		SendMessage: function(message){
     			return sendMessage(message);
     		}
     	};
	});