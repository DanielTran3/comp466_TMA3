SELECT cpu.brand as cpu, cpu.model as cpu, cpu.clock, cpu.cache, cpu.socket, cpu.price, 
ram.brand, ram.model, ram.speed, ram.memoryType, ram.price,
hd.brand, hd.model, hd.type, hd.size, hd.readSpeed, hd.writeSpeed, hd.price,
d.brand, d.model, d.size, d.resolution, d.responseTime, d.price,
os.brand, os.version, os.price,
sc.brand, sc.model, sc.price
FROM display d, harddrive hd, operatingSystem os, processor cpu, ram, soundCard sc, prebuiltSystems pbs 
WHERE pbs.display = d.ID AND
pbs.hardDrive = hd.ID AND
pbs.operatingSystem = os.ID AND
pbs.processor = cpu.ID AND
pbs.ram = ram.ID AND
pbs.soundCard = sc.ID;