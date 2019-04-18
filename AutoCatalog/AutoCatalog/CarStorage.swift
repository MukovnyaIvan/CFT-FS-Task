//
//  CarStorage.swift
//  AutoCatalog
//
//  Created by Student on 02/04/2019.
//  Copyright © 2019 Student. All rights reserved.
//

import Foundation

public class CarStorage {
    private var cars: [Car] = []
    private lazy var  fileURL: URL = {
        let directoryURL = FileManager.default.homeDirectoryForCurrentUser
        return directoryURL.appendingPathComponent("cars.data")
    }()
    
    init() {
        load()
    }
    
    func append(car: Car) -> Bool {
        assert(!cars.contains(where: {car === $0 }))
        cars.append(car)
        return save()
    }
    
    func remove(car: Car) -> Bool {
        assert(cars.contains(where: {car === $0 }))
        cars.removeAll {$0 === car}
        return save()
    }
    
    func getCar(index: Int) -> Car{
        
        return cars[index]
    }
    
    func modify(oldCar: Car, newCar: Car) -> Bool {
        assert(cars.contains(where: {oldCar === $0 }))
        if let index = cars.firstIndex(where: {oldCar === $0} ) {
            cars[index] = newCar
            return save()
        }
        return false
    }
    
    func getCarCount() -> Int{
        return cars.count
    }
    
    func isIntexInBounds(index:Int) -> Bool{
        return (index < cars.count && index >= 0)
    }
    
    private func save() -> Bool {
        
        
        if let data: Data = try? JSONEncoder().encode(cars) {
            return nil != (try? data.write(to: fileURL))
        }
        return false
    }
    
    @discardableResult
    private func load() -> Bool {
        
        do {
            let data = try Data(contentsOf: fileURL)
            cars = try JSONDecoder().decode([Car].self, from: data)
            return true
        } catch {
            return false
        }
    }
}
