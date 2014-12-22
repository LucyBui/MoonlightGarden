package com.moonlightgarden;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.ComponentScan;

import com.moonlightgarden.service.SeedingService;

@ComponentScan
@EnableAutoConfiguration
public class Application {

  public static void main(String[] args) {
    ApplicationContext appContext = SpringApplication.run(Application.class, args);
    SeedingService seedingService = appContext.getBean(SeedingService.class);
    seedingService.seedMasterData();
  }

}
