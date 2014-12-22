package com.moonlightgarden.controller;

import static org.springframework.web.bind.annotation.RequestMethod.GET;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.moonlightgarden.domain.Family;
import com.moonlightgarden.util.ApiResponse;

@RestController
@RequestMapping(value="/api/family")
public class FamilyController {
  @RequestMapping(value="/{id}", method=GET)
  public ApiResponse getFamilyById(@RequestParam(value="id", defaultValue="test") String id) {
    return new ApiResponse(new Family());
  }
}
