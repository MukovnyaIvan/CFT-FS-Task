//
//  Car.swift
//  AutoCatalog
//
//  Created by Student on 02/04/2019.
//  Copyright © 2019 Student. All rights reserved.
//

import Foundation

public class Car: Codable {
    
    public enum Property : String {
        case manufacturer
        case model
        case bodyType
        case year
        case `class`
        
        static let allValues: [Property] = [.manufacturer, .model, .bodyType, .year, .class]
    }
    
    private var data: [String] = []
    
    subscript(property: Property) -> String {
        get {
            if let index = Property.allValues.firstIndex(of: property), index < data.count {
                return data[index]
            }
            return ""
        }
        set{
            if let index = Property.allValues.firstIndex(of: property) {
                while data.count <= index{
                    data.append("")
                }
                data[index] = newValue
            }
        }
    }
    
    
    init(){
        data = [String].init(repeating: "", count: Property.allValues.count)
    }
    
    
    
    public required init (from decoder: Decoder) throws {
        let container  = try decoder.singleValueContainer()
        data = try container.decode([String].self)
    }
    
    public func encode(to encoder: Encoder) throws {
        var container = encoder.singleValueContainer()
        //            let result = data.reduce(into: [String:String](),{ acc, pair in
        //                acc[pair.key.rawValue] = pair.value
        //
        //            } )
        try container.encode(data)
    }
    
}

