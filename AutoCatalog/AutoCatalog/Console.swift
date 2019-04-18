//
//  Console.swift
//  AutoCatalog
//
//  Created by Student on 02/04/2019.
//  Copyright © 2019 Student. All rights reserved.
//

import Foundation

public class Console {
    
    enum Commands: String {
        case help
        case print
        case mod
        case delete
        case add
        
        static let allValues:[Commands] = [.help, .print, .mod, .delete, .add]
    }
    let storage : CarStorage
    
    init(storage : CarStorage) {
        self.storage = storage
    }
    
    
    func printHelp(){
        print("""
            There you have following commands:
            '\(Commands.print.rawValue)' to print all cars
            '\(Commands.add.rawValue)' to add a new car
            '\(Commands.mod.rawValue)' to change car's info
            '\(Commands.delete.rawValue)' to delete a car
            """)
    }
    
    func printCar(index: Int){
        let car = storage.getCar(index: index)
        var result = "\(index) : ["
        for prop in Car.Property.allValues {
            result.append("\(prop.rawValue): \(car[prop]) | ")
        }
        result.removeLast(2)
        result.append("]")
        print(result)
    }
    
    func addCar() {
        print("Manufacturer: ")
        let manufacturer = readLine()
        print("Model: ")
        let model = readLine()
        print("Body type: ")
        let body = readLine()
        print("Year: ")
        let year = readLine()
        print("Class: ")
        let carClass = readLine()
        
        let car = Car()
        car[.manufacturer] = manufacturer ?? car[.manufacturer]
        car[.model] = model ?? car[.model]
        car[.bodyType] = body ?? car[.bodyType]
        car[.year] = year ?? car[.year]
        car[.class] = carClass ?? car[.class]
        
        if (!storage.append(car: car))
        {
            print("Saving error occured")
        }
    }
    
    func deleteCar(with index: Int) {
        if (!storage.remove(car: storage.getCar(index: index)))
        {
            print("There is no car with such index")
        }
    }
    
    func printAllCars() {
        var index = 0
        while (storage.isIntexInBounds(index: index))
        {
            printCar(index: index)
            index += 1
        }
    }
    
    func modifyCar(with index: Int) {
        if (!storage.isIntexInBounds(index: index)){
            print("There is no car with such index")
            return
        }
        
        print("Just press Enter if you want to keep old value")
        let car = storage.getCar(index: index)
        for prop in Car.Property.allValues {
            print("\(prop.rawValue) (old: \(car[prop])): ")
            if let value = readLine(){
                if value == ""{
                    continue
                }
                else{
                    car[prop] = value
                }
            }
        }
        storage.modify(oldCar: storage.getCar(index: index), newCar: car)
    }
    
    func getIndex(from str: String?) -> Int{
        if let string = str, let index = Int(string){
            return index
        }
        return -1
    }
    
    
    public func run(){
        while true{
            let command = readLine()
            switch (command){
            case Commands.help.rawValue:
                printHelp()
            case Commands.add.rawValue:
                addCar()
            case Commands.delete.rawValue:
                print("Enter the index")
                deleteCar(with: getIndex(from: readLine()))
            case Commands.mod.rawValue:
                print("Enter the index")
                modifyCar(with: getIndex(from: readLine()))
            case Commands.print.rawValue:
                printAllCars()
            case "":
                continue
            default: print("'\(command!)' is not a command. Enter 'help' to see more information")
            }
        }
    }
}
