//
//  ViewController.m
//  app
//
//  Created by oneRain on 2022/8/17.
//

#import "ViewController.h"
#import "hello/Hello.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    [Hello print:@"Hello, world."];
}


@end
