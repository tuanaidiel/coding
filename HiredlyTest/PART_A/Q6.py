def calculate_shipping_cartons(total_boxes=96):

    for huge_cartons in range(1, total_boxes // 8 + 1):
        huge_boxes = huge_cartons * 8
        remaining_boxes = total_boxes - huge_boxes
        
        for small_cartons in range(1, remaining_boxes // 10 + 1):
            small_boxes = small_cartons * 10

            if (huge_boxes + small_boxes == total_boxes and 
                huge_boxes > small_boxes):
                return {
                    'total_cartons': huge_cartons + small_cartons,
                    'huge_cartons': huge_cartons,
                    'small_cartons': small_cartons,
                    'huge_boxes': huge_boxes,
                    'small_boxes': small_boxes
                }
    return None  

result = calculate_shipping_cartons()

if result:
    print("Shipping Carton Calculation:")
    print(f"Total Cartons: {result['total_cartons']}")
    print(f"Huge Cartons: {result['huge_cartons']} (containing {result['huge_boxes']} boxes)")
    print(f"Small Cartons: {result['small_cartons']} (containing {result['small_boxes']} boxes)")
else:
    print("No solution found")