//
//  Hello.h
//  hello
//
//  Created by oneRain on 2022/8/17.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface Hello : NSObject

+ (void)print:(NSString*)message;

+ (void)showDialog;

+ (void)call;

+ (void)callAsync:(void(^)(int))callback;

@end

NS_ASSUME_NONNULL_END
