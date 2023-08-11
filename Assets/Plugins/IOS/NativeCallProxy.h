//
//  NativeCallProxy.h
//  Unity-iPhone
//
//  Created by 罗平 on 2021/9/4.
//

#import <Foundation/Foundation.h>
@protocol NativeCallsProtocol

@required


//骑行坡度
- (void)LoadSceneSucceeded:(NSString *)value;
- (void)LoadSceneActionFinish:(NSString *)value;


@end

__attribute__ ((visibility("default")))

@interface FrameworkLibAPI : NSObject
// call it any time after UnityFrameworkLoad to set object implementing NativeCallsProtocol methods
+(void) registerAPIforNativeCalls:(id<NativeCallsProtocol>) aApi;

@end


