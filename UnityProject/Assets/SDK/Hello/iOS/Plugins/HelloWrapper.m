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

void _Call() {
	[Hello call];
}

typedef void (*OnMessage)(const char* message);

void _RegisterHelloCallback(OnMessage func) {
	dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_DEFAULT, 0), ^{
        func("I am from iOS.");
    });
}

typedef void (*OnRandom)(int rand);

void _RegisterRandomCallback(OnRandom func) {
    [Hello callAsync:^(int rand) {
        func(rand);
    }];
}
