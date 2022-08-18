//
//  HelloWrapper.m
//  Unity-iPhone
//
//  Created by oneRain on 2022/8/18.
//

#import <Foundation/Foundation.h>
#import "hello/Hello.h"

void _Print(const char* message) {
    [Hello print:[NSString stringWithUTF8String:message]];
}

void _ShowDialog() {
    [Hello showDialog];
}
