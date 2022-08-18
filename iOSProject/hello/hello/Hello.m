//
//  Hello.m
//  hello
//
//  Created by oneRain on 2022/8/17.
//

#import <UIKit/UIKit.h>
#import "Hello.h"

@implementation Hello

+ (void)print:(NSString*)message {
    NSLog(@"%@", message);
}

+ (void)showDialog {
    UIAlertView *alertView = [[UIAlertView alloc]initWithTitle:@"Title" message:@"This is a test alert" delegate:nil
       cancelButtonTitle:@"Cancel" otherButtonTitles:@"Ok", nil];
    [alertView show];
}

@end
