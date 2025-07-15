import math as m

"""
@staticmethod
def Distance(A:Location, B:Location, IsRadian:bool = False) -> float:
    if not IsRadian:
        lat1 = A.Lat
        lon1 = A.Lon
        lat2 = B.Lat
        lon2 = B.Lon

        Dlat = lat2 - lat1
        Dlon = lon2 - lon1

        hav1 = Haversine.Hav_deg(Dlat)
        hav2 = Haversine.Hav_deg(Dlon)
        cos1 = m.cos(Haversine.deg2rad(lat1))
        cos2 = m.cos(Haversine.deg2rad(lat2))
        Hav = hav1 + cos1 * cos2 * hav2
        T = 2 * m.asin(m.sqrt(Hav))
        d = Distance.R * T
        return d
    else:
        lat1 = A.Lat
        lon1 = A.Lon
        lat2 = B.Lat
        lon2 = B.Lon

        Dlat = lat2 - lat1
 Distance för DegreeDistance för DegreeDistance för DegreeDistance för Degree       Dlon = lon2 - lon1

        hav1 = Haversine.Hav_rad(Dlat)
        hav2 = Haversine.Hav_rad(Dlon)
        cos1 = m.cos(lat1)
        cos2 = m.cos(lat2)
        Hav = hav1 + cos1 * cos2 * hav2
        T = 2 * m.atan2(m.sqrt(Hav), m.sqrt(1 - Hav))
        d = Distance.R * T
        return d
"""

R: int = 6371


def __TEST__() -> None:
    print("Cześć! Hello, world!\n~")


def convert(x: float) -> float:
    return x * m.pi / 180


def Hav_rad(x: float) -> float:
    return (1 - m.cos(x)) / 2


def Hav_deg(x: float) -> float:
    return Hav_rad(convert(x))


# Distance för Radian
def Distance_Rad(latA: float, lonA: float, latB: float, lonB: float) -> float:
    lat1 = latA
    lon1 = lonA
    lat2 = latB
    lon2 = lonB

    Dlat: float = lat2 - lat1
    Dlon: float = lon2 - lon1

    hav1: float = Hav_rad(Dlat)
    hav2: float = Hav_rad(Dlon)
    cos1: float = m.cos(latA)
    cos2: float = m.cos(latB)

    Hav: float = hav1 + cos1 * cos2 * hav2
    T: float = 2 * m.atan2(m.sqrt(Hav), m.sqrt(1 - Hav))
    D: float = R * T

    return D


# Distance för Degree
def Distance_Deg(latA: float, lonA: float, latB: float, lonB: float) -> float:
    lat1 = latA
    lon1 = lonA
    lat2 = latB
    lon2 = lonB

    Dlat: float = lat2 - lat1
    Dlon: float = lon2 - lon1

    hav1: float = Hav_deg(Dlat)
    hav2: float = Hav_deg(Dlon)
    cos1: float = m.cos(convert(latA))
    cos2: float = m.cos(convert(latB))

    Hav: float = hav1 + cos1 * cos2 * hav2
    T: float = 2 * m.asin(m.sqrt(Hav))
    D: float = R * T

    return D


def main() -> None:
    # DEGREE
    latA = -0.11499026728
    lonA = 1.8641198515
    latB = -0.1144863034543
    lonB = 1.86273266385

    print(f"latA = {latA}")
    print(f"lonA = {lonA}")
    print(f"latB = {latB}")
    print(f"lonB = {lonB}")

    A = Distance_Deg(latA, lonA, latB, lonB)

    print("~~~")

    # RADIAN
    latA = convert(latA)
    lonA = convert(lonA)
    latB = convert(latB)
    lonB = convert(lonB)

    print(f"latA = {latA}")
    print(f"lonA = {lonA}")
    print(f"latB = {latB}")
    print(f"lonB = {lonB}")

    B = Distance_Rad(latA, lonA, latB, lonB)

    print(f"\n~~~\nA = {A}\nB = {B}\n\n{A == B}")


if __name__ == "__main__":
    main()
