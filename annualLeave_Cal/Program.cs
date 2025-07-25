DateTime startWorkingPositionDate = DateTime.Parse("2024-12-25"); // วันบรรจุ YYYY-MM-DD
//DateTime now = DateTime.Today; // วันปัจจุบัน
DateTime now = DateTime.Parse("2025-12-23"); // สำหรับอยากเปลี่ยนวันปัจจุบัน YYYY-MM-DD

int leaveDays = CalculateVacationLeave(startWorkingPositionDate, now);

Console.WriteLine($"{leaveDays} days");


static int CalculateVacationLeave(DateTime startDate, DateTime now)
{
    int yearDiff = now.Year - startDate.Year;

    // Adjust year if anniversary hasn't occurred yet this year
    if ((yearDiff <= 1 && now.Month < startDate.Month) || (now.Month == startDate.Month && now.Day < startDate.Day))
    {
        yearDiff--;
    }

    // Still in first year (joined this year)
    if (yearDiff == 1)
    {
        return GetPartialLeaveByJoinMonth(startDate.Month);
    }

    // Full years of service
    if (yearDiff >= 6) return 10; // มากกว่าหรือเท่ากับ 6 ปี ลาได้ 10 วัน
    if (yearDiff == 5) return 9; // เท่ากับ 5 ปี ลาได้ 9 วัน
    if (yearDiff == 4) return 8; // เท่ากับ 4 ปี ลาได้ 8 วัน
    if (yearDiff == 3) return 7; // เท่ากับ 3 ปี ลาได้ 7 วัน
    if (yearDiff == 2) return 6; // เท่ากับ 2 ปี ลาได้ 6 วัน
    return 0;
}

// สำหรับทำงาน ครบ 1 ปี แต่ครบแบบไม่เต็มปี
static int GetPartialLeaveByJoinMonth(int joinMonth)
{
    // Based on second table
    return joinMonth switch
    {
        1 => 5, // ถ้าทำงานครบ 1 ปี เดือน มกราคม ลาได้ 5 วัน
        2 => 4,
        3 => 4,
        4 => 3,
        5 => 3,
        6 => 3,
        7 => 2,
        8 => 2,
        9 => 1,
        10 => 1,
        11 => 1,
        12 => 0,
        _ => 0
    };
}



//DateTime startWorkingPositionDate = DateTime.Parse("2024-07-23"); // YYYY-MM-DD
//DateTime now = DateTime.Now;
////DateTime now = new DateTime(2026, 1, 1); // Replace with your input 


//int yearDiff = now.Year - startWorkingPositionDate.Year;

//bool isFullYear = false;

//// Condition for special case
//// if startDate = 2024-07-22 and today = 2025-07-21 => Not full month must do yearDiff - 1
//// But if startDate and today, Years are morn than 1, Not yearDiff - 1
//if ((yearDiff <= 1 && now.Month < startWorkingPositionDate.Month) || (now.Month == startWorkingPositionDate.Month && now.Day < startWorkingPositionDate.Day))
//{
//    //isFullYear = true;
//    yearDiff--;
//}

//if (yearDiff >= 6)
//{
//    Console.WriteLine("10 day");
//}
//else if (yearDiff >= 5)
//{
//    Console.WriteLine("9 day");
//}
//else if (yearDiff >= 4)
//{
//    Console.WriteLine("8 day");
//}
//else if (yearDiff >= 3)
//{
//    Console.WriteLine("7 day");
//}
//else if (yearDiff >= 2)
//{
//    Console.WriteLine("6 day");
//}
//else if (yearDiff >= 1)
//{
//    //if (isFullYear == true)
//    //{
//    //    Console.WriteLine("5 day");
//    //    return;
//    //}

//    if (startWorkingPositionDate.Month >= 12)
//    {
//        Console.WriteLine("0 day");
//    }
//    else if (startWorkingPositionDate.Month >= 9 && startWorkingPositionDate.Month <= 11)
//    {
//        Console.WriteLine("1 day");
//    }
//    else if (startWorkingPositionDate.Month >= 7 && startWorkingPositionDate.Month <= 8)
//    {
//        Console.WriteLine("2 day");
//    }
//    else if (startWorkingPositionDate.Month >= 4 && startWorkingPositionDate.Month <= 6)
//    {
//        Console.WriteLine("3 day");
//    }
//    else if (startWorkingPositionDate.Month >= 2 && startWorkingPositionDate.Month <= 3)
//    {
//        Console.WriteLine("4 day");
//    }
//    else
//    {
//        Console.WriteLine("5 day");
//    }
//}
//else
//{
//    Console.WriteLine("0 day");
//    // Do nothing
//}