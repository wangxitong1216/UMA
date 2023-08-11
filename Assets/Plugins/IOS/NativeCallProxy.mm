//
//  NativeCallProxy.m
//  Unity-iPhone
//
//  Created by 罗平 on 2021/9/4.
//

#import <Foundation/Foundation.h>
#import "NativeCallProxy.h"


@implementation FrameworkLibAPI

id<NativeCallsProtocol> api = NULL;
+(void) registerAPIforNativeCalls:(id<NativeCallsProtocol>) aApi
{
    api = aApi;
}

@end


extern "C" {

void LoadSceneSucceeded(const char * value);
void LoadSceneActionFinish(const char * value);
}


void LoadSceneSucceeded(const char * value){
    
    return [api LoadSceneSucceeded:[NSString stringWithUTF8String:value]];    
}

void LoadSceneActionFinish(const char * value){
 
    return [api LoadSceneActionFinish:[NSString stringWithUTF8String:value]];
}