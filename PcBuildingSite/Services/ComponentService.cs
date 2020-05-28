using Data;
using PcBuildingSite.Controllers;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Data.Models.Component;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;


namespace PcBuildingSite.Services
{
    public class ComponentService
    {
        private readonly AppDbContext context;
        public ComponentService(AppDbContext context)
        {
            this.context = context;
        }

        public CPU GetCpuFromModel(string cpuModel)
        {
            CPU processor = new CPU();
            foreach (var cpu in context.cpus)
            {
                if (cpuModel == cpu.model)
                {
                    processor = cpu;
                }
            }
            return processor;
        }
        public Gpu GetGpuFromModel(string gpuModel)
        {
            Gpu graphCard = new Gpu();
            foreach (var gpu in context.gpus)
            {
                if (gpuModel == gpu.model)
                {
                    graphCard = gpu;
                }
            }
            return graphCard;
        }
        public RAM GetRamFromModel(string ramModel)
        {
            RAM resultRam = new RAM();
            foreach (var ram in context.rams)
            {
                if (ramModel == ram.model)
                {
                    resultRam = ram;
                }
            }
            return resultRam;
        }
        public PcStorage GetStorageFromModel(string storageModel)
        {
            PcStorage resultStorage = new PcStorage();
            foreach (var storage in context.storages)
            {
                if (storageModel == storage.model)
                {
                    resultStorage = storage;
                }
            }
            return resultStorage;
        }
        public PSU GetPsuFromModel(string psuModel)
        {
            PSU resultPsu = new PSU();
            foreach (var psu in context.psus)
            {
                if (psuModel == psu.model)
                {
                    resultPsu = psu;
                }
            }
            return resultPsu;
        }
        public PcCase GetCaseFromModel(string caseModel)
        {
            PcCase resultCase = new PcCase();
            foreach (var pcCase in context.cases)
            {
                if (caseModel == pcCase.model)
                {
                    resultCase = pcCase;
                }
            }
            return resultCase;
        }
        public Motherboard GetMotherboardFromModel(string motherboardModel)
        {
            Motherboard resultMotherboard = new Motherboard();
            foreach (var motherboard in context.motherboards)
            {
                if (motherboardModel == motherboard.model)
                {
                    resultMotherboard = motherboard;
                }
            }
            return resultMotherboard;
        }
        public bool HasTheSameIdInBase(string idOrModel)
        {

            foreach (var cpu in context.cpus)
            {
                if (idOrModel == cpu.model)
                {
                    return true;
                }
            }
            foreach (var gpu in context.gpus)
            {
                if (idOrModel == gpu.model)
                {
                    return true;
                }
            }
            foreach (var ram in context.rams)
            {
                if (idOrModel == ram.model)
                {
                    return true;
                }
            }
            foreach (var motherboard in context.motherboards)
            {
                if (idOrModel == motherboard.model)
                {
                    return  true;
                }
            }
            foreach (var pcCase in context.cases)
            {
                if (idOrModel == pcCase.model)
                {
                    return true;
                }
            }
            foreach (var psu in context.psus)
            {
                if (idOrModel == psu.model)
                {
                    return true;
                }
            }
            foreach (var storage in context.storages)
            {
                if (idOrModel == storage.model)
                {
                    return true;
                }
            }
            foreach (var computer in context.Computer)
            {
                if (idOrModel == computer.id.ToString())
                {
                    return true;
                }
            }

            return false;
        }
        public double GetPrice(string cpuModel, string gpuModel, string ramModel, string storageModel, string psuModel, string caseModel, string motherboardModel)
        {
            double cpuPrice = GetCpuFromModel(cpuModel).price;
            double gpuPrice = GetGpuFromModel(gpuModel).price;
            double ramPrice = GetRamFromModel(ramModel).price;
            double motherboardPrice = GetStorageFromModel(storageModel).price; 
            double casePrice = GetPsuFromModel(psuModel).price;
            double psuPrice = GetCaseFromModel(caseModel).price;
            double storagePrice = GetMotherboardFromModel(motherboardModel).price;
            double computerTotalPrice = 0;

            computerTotalPrice = cpuPrice + gpuPrice + ramPrice + motherboardPrice + casePrice + storagePrice + psuPrice;
            return computerTotalPrice;
        }

        public double GetPerformance(string cpuModel, string gpuModel, string ramModel)
        {
            CPU cpu = GetCpuFromModel(cpuModel);
            Gpu gpu = GetGpuFromModel(gpuModel);
            RAM ram = GetRamFromModel(ramModel);
            double PerformanceScore = ((cpu.cores * cpu.frequency * 10))
                + ((gpu.frequency * gpu.cores) + (gpu.rtCores * 2)) + ram.frequency * ram.memorysize;
            return PerformanceScore;
        }

        public bool SocketIsCompadable(string cpuModel, string motherboardModel)
        {
            string CpuSocket = GetCpuFromModel(cpuModel).socket;
            string MotherboardSocket = GetMotherboardFromModel(motherboardModel).socket;
         
            if (CpuSocket == MotherboardSocket)
            {
                return true;
            }
            return false;
        }
        public bool FormFactorIsCompadable(string caseModel, string motherboardModel)
        {
            string caseSupportedSizesInString = GetCaseFromModel(caseModel).formfactor;
            string motherboardSize = GetMotherboardFromModel(motherboardModel).formfactor;
                 
            List<string> caseSupportedSizes = caseSupportedSizesInString.ToLower().Split(",").ToList();

            foreach (var supportedSizeByCase in caseSupportedSizes)
            {
                if (supportedSizeByCase.ToLower() == motherboardSize.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        //public bool CrossfireOrSliSupport(Gpu gpu, Motherboard motherBoard)
        //{
        //    if (gpu.SliCrossfireSupport == motherBoard.sliCrossfireSuport)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //public string StackRam(List<RAM> RamInSlots)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var ram in RamInSlots)
        //    {
        //        sb.Append(ram.model + ",");
        //    }
        //    return sb.ToString();
        //}
        // public string StackSSDs(List<SSD> SSDs)
        // {
        //     StringBuilder sb = new StringBuilder();
        //    foreach (var ssd in SSDs)
        //    {
        //       sb.Append(ssd.Model + ",");
        //     }
        //      return sb.ToString();
        //  }
        // public string StackHDD(List<HDD> HDDs)
        //  {
        ////      StringBuilder sb = new StringBuilder();
        //      foreach (var hdd in HDDs)
        //      {
        //         sb.Append(hdd.Model + ",");
        //      }
        //      return sb.ToString();
        //   }
        public bool GenerationIsCompadable(string cpuModel, string motherboardModel)
        {
            string cpuGeneration = GetCpuFromModel(cpuModel).generation;
            List<string> motherboardSupportetGenerations =
                GetMotherboardFromModel(motherboardModel).suportedGeneration
                .Split(",").ToList();
           
            foreach (var generation in motherboardSupportetGenerations)
            {
                if (generation == cpuGeneration)
                {
                    return true;
                }
            }

            return false;
        }
        public bool IsPowerEnough(string psuModel, string cpuModel, string gpuModel, int gpuNumber)
        {
            int psuPowerEfficiency = GetPsuFromModel(psuModel).powerEfficiency;
            int TotalPowerConsumption = GetPowerDraw(cpuModel, gpuModel, gpuNumber);
           
            if (psuPowerEfficiency < TotalPowerConsumption)
            {
                return false;
            }
            else return true;
        }
        private int GetPowerDraw(string cpuModel, string gpuModel, int gpuNumber)
        {
            int cpuPowerDraw = GetCpuFromModel(cpuModel).tdp;
            int gpuPowerDraw = GetGpuFromModel(gpuModel).tdp;

            int Powerdraw = (cpuPowerDraw + gpuPowerDraw * gpuNumber) + 10;
            return Powerdraw;

        }
        //public double GetPerformance(CPU cpu, Gpu gpu, RAM ram)
        //{
        //    double PerformanceScore = ((cpu.cores * cpu.frequency * 10) - cpu.tdp)
        //        + ((gpu.frequency * gpu.cores) - gpu.tdp + (gpu.rtCores * 2)) + ram.frequency * ram.memorysize;
        //    return PerformanceScore;
        //}
        public void CreateGPU(GpuDto gpu)
        {
            this.context.gpus.Add(this.OfGpuDto(gpu));
            this.context.SaveChanges();
        }
        public void DeleteComponent(GpuDto gpu)
        {
            var gpuToDelete = this.context.gpus.FirstOrDefault(c => c.model == gpu.model);

            this.context.gpus.Remove(gpuToDelete);

            this.context.SaveChanges();
        }

        public GpuDto GetGpuById(string id)
        {
            GpuDto gpuDto = new GpuDto();
            Gpu gpu = this.context.gpus.FirstOrDefault(x => x.model == id);

            gpuDto.model = gpu.model;
            gpuDto.frequency = gpu.frequency;
            gpuDto.vramSpeed = gpu.vramSpeed;
            gpuDto.cores = gpu.cores;
            gpuDto.rtCores = gpu.rtCores;
            gpuDto.memoryQuantity = gpu.memoryQuantity;
            gpuDto.tdp = gpu.tdp;
            gpuDto.SliCrossfireSupport = gpu.SliCrossfireSupport;
            gpuDto.price = gpu.price;

            return gpuDto;
        }
        public Gpu OfGpuDto(GpuDto gpuDto)
        {
            return new Gpu()
            {
                model = gpuDto.model,
                frequency = gpuDto.frequency,
                vramSpeed = gpuDto.vramSpeed,
                cores = gpuDto.cores,
                rtCores = gpuDto.rtCores,
                memoryQuantity = gpuDto.memoryQuantity,
                tdp = gpuDto.tdp,
                SliCrossfireSupport = gpuDto.SliCrossfireSupport,
                price = gpuDto.price
            };
        }
        public void DeleteCpu(CpuDto cpu)
        {
            var cpuToDelete = this.context.cpus.FirstOrDefault(c => c.model == cpu.model);

            this.context.cpus.Remove(cpuToDelete);

            this.context.SaveChanges();
        }

        public CpuDto GetByCpuId(string id)
        {
            CpuDto cpuDto = new CpuDto();
            CPU cpu = this.context.cpus.FirstOrDefault(x => x.model == id);

            cpuDto.model = cpu.model;
            cpuDto.socket = cpu.socket;
            cpuDto.frequency = cpu.frequency;
            cpuDto.cores = cpu.cores;
            cpuDto.threads = cpu.threads;
            cpuDto.cpuBrand = cpu.cpuBrand;
            cpuDto.generation = cpu.generation;
            cpuDto.tdp = cpu.tdp;
            cpuDto.price = cpu.price;

            return cpuDto;
        }
        public void CreateCPU(CpuDto cpu)
        {
            this.context.cpus.Add(this.OfCpuDto(cpu));
            this.context.SaveChanges();
        }
        public CPU OfCpuDto(CpuDto cpu)
        {
            return new CPU()
            {
                model = cpu.model,
                socket = cpu.socket,
                frequency = cpu.frequency,
                cores = cpu.cores,
                threads = cpu.threads,
                cpuBrand = cpu.cpuBrand,
                generation = cpu.generation,
                tdp = cpu.tdp,
                price = cpu.price
            };
        }
        public void CreateMotherboard(MotherboardDto motherboard)
        {
            this.context.motherboards.Add(this.OfMotherboardDto(motherboard));
            this.context.SaveChanges();
        }
        public void DeleteMotherboard(MotherboardDto motherboard)
        {
            var motherboardToDelete = this.context.motherboards.FirstOrDefault(c => c.model == motherboard.model);

            this.context.motherboards.Remove(motherboardToDelete);

            this.context.SaveChanges();
        }

        public MotherboardDto GetMotherboardById(string id)
        {
            MotherboardDto motherboardDto = new MotherboardDto();
            Motherboard motherboard = this.context.motherboards.FirstOrDefault(x => x.model == id);

            motherboardDto.model = motherboard.model;
            motherboardDto.socket = motherboard.socket;
            motherboardDto.ramSlots = motherboard.ramSlots;
            motherboardDto.formfactor = motherboard.formfactor;
            motherboardDto.sliCrossfireSuport = motherboard.sliCrossfireSuport;
            motherboardDto.suportedGeneration = motherboard.suportedGeneration;
            motherboardDto.price = motherboard.price;

            return motherboardDto;
        }
        public Motherboard OfMotherboardDto(MotherboardDto motherboard)
        {
            return new Motherboard()
            {
                model = motherboard.model,
                socket = motherboard.socket,
                ramSlots = motherboard.ramSlots,
                formfactor = motherboard.formfactor,
                sliCrossfireSuport = motherboard.sliCrossfireSuport,
                suportedGeneration = motherboard.suportedGeneration,
                price = motherboard.price
            };
        }
        public void CreateRam(RamDto ram)
        {
            this.context.rams.Add(this.OfRamDto(ram));
            this.context.SaveChanges();
        }
        public void DeleteRam(RamDto ram)
        {
            var ramToDelete = this.context.rams.FirstOrDefault(c => c.model == ram.model);

            this.context.rams.Remove(ramToDelete);

            this.context.SaveChanges();
        }

        public RamDto GetRamById(string id)
        {
            RamDto ramDto = new RamDto();
            RAM ram = this.context.rams.FirstOrDefault(x => x.model == id);


            ramDto.model = ram.model;
            ramDto.frequency = ram.frequency;
            ramDto.memorysize = ram.memorysize;
            ramDto.price = ram.price;

            return ramDto;
        }
        public RAM OfRamDto(RamDto ram)
        {
            return new RAM()
            {
                model = ram.model,
                frequency = ram.frequency,
                memorysize = ram.memorysize,
                price = ram.price
            };
        }
        public void CreatePcCase(PcCaseDto pcCase)
        {
            this.context.cases.Add(this.OfPcCaseDto(pcCase));
            this.context.SaveChanges();
        }
        public void DeletePcCase(PcCaseDto pcCase)
        {
            var pcCaseToDelete = this.context.cases.FirstOrDefault(c => c.model == pcCase.model);

            this.context.cases.Remove(pcCaseToDelete);

            this.context.SaveChanges();
        }

        public PcCaseDto GetPcCaseById(string id)
        {
            PcCaseDto pcCaseDto = new PcCaseDto();
            PcCase pcCase = this.context.cases.FirstOrDefault(x => x.model == id);


            pcCaseDto.model = pcCase.model;
            pcCaseDto.formfactor = pcCase.formfactor;
            pcCaseDto.price = pcCase.price;

            return pcCaseDto;
        }
        public PcCase OfPcCaseDto(PcCaseDto pcCase)
        {
            return new PcCase()
            {
                model = pcCase.model,
                formfactor = pcCase.formfactor,
                price = pcCase.price
            };
        }
        public void CreatePcStorage(PcStorageDto storage)
        {
            this.context.storages.Add(this.OfPcStorageDto(storage));
            this.context.SaveChanges();


        }
        public void DeletePcStorage(PcStorageDto pcStorage)
        {
            var pcStorageToDelete = this.context.storages.FirstOrDefault(c => c.model == pcStorage.model);

            this.context.storages.Remove(pcStorageToDelete);

            this.context.SaveChanges();
        }

        public PcStorageDto GetPcStorageById(string id)
        {
            PcStorageDto pcStorageDto = new PcStorageDto();
            PcStorage pcSorage = this.context.storages.FirstOrDefault(x => x.model == id);


            pcStorageDto.model = pcSorage.model;
            pcStorageDto.memeorySize = pcSorage.memeorySize;
            pcStorageDto.price = pcSorage.price;
            pcStorageDto.readSpeed = pcSorage.readSpeed;
            pcStorageDto.ssdOrHdd = pcSorage.ssdOrHdd;
            pcStorageDto.writeSpeed = pcSorage.writeSpeed;

            return pcStorageDto;
        }
        public PcStorage OfPcStorageDto(PcStorageDto storage)
        {
            return new PcStorage()
            {
                model = storage.model,
                memeorySize = storage.memeorySize,
                price = storage.price,
                readSpeed = storage.readSpeed,
                ssdOrHdd = storage.ssdOrHdd,
                writeSpeed = storage.writeSpeed
            };
        }
        public void CreatePsu(PsuDto psu)
        {
            this.context.psus.Add(this.OfPcPsuDto(psu));
            this.context.SaveChanges();


        }
        public void DeletePSU(PsuDto psu)
        {
            var psuToDelete = this.context.psus.FirstOrDefault(c => c.model == psu.model);

            this.context.psus.Remove(psuToDelete);

            this.context.SaveChanges();
        }

        public PsuDto GetPsuById(string id)
        {
            PsuDto psuDto = new PsuDto();
            PSU psu = this.context.psus.FirstOrDefault(x => x.model == id);


            psuDto.model = psu.model;
            psuDto.powerEfficiency = psu.powerEfficiency;
            psuDto.price = psu.price;

            return psuDto;
        }
        public PSU OfPcPsuDto(PsuDto psu)
        {
            return new PSU()
            {
                model = psu.model,
                powerEfficiency = psu.powerEfficiency,
                price = psu.price
            };
        }
        public void CreateComputer(ComputerDto computer)
        {

            if (PartsInStorage(OfComputerDto(computer)))
            {
                this.context.Computer.Add(this.OfComputerDto(computer));
                this.context.SaveChanges();
            }

        }
        public Computer OfComputerDto(ComputerDto computer)
        {

            return new Computer()
            {
                cpuModel = computer.cpuModel,
                gpuModel = computer.gpuModel,
                ramModel = computer.ramModel,
                motherboardModel = computer.motherboardModel,
                pcCaseModel = computer.pcCaseModel,
                psuModel = computer.psuModel,
                storageModel = computer.storageModel,
                price = computer.price = GetPrice(computer.cpuModel, computer.gpuModel, computer.ramModel, computer.storageModel, computer.psuModel, computer.pcCaseModel, computer.motherboardModel)

            };

        }
        public bool PartsInStorage(Computer computer)
        {
            bool HasCpu = HasTheSameIdInBase(computer.cpuModel);
            bool HasGpu = HasTheSameIdInBase(computer.gpuModel);
            bool HasRam = HasTheSameIdInBase(computer.ramModel);
            bool HasMotherboard = HasTheSameIdInBase(computer.motherboardModel);
            bool HasCase = HasTheSameIdInBase(computer.pcCaseModel);
            bool HasPsu = HasTheSameIdInBase(computer.psuModel);
            bool HasStorage = HasTheSameIdInBase(computer.storageModel);

            if (HasCpu == true && HasGpu == true && HasRam == true && HasMotherboard == true && HasPsu == true && HasStorage == true && HasCase == true)
            {
                return true;
            }
            return false;

        }
        public List<string> GetAllCpuModels()
        {
            List<CPU> cpuList = new List<CPU>();
            List<string> cpuModels = new List<string>();

            foreach (var cpu in context.cpus)
            {
                cpuList.Add(cpu);
            }
            foreach (var cpuSuggestion in cpuList)
            {
                cpuModels.Add(cpuSuggestion.model);
            }
            return cpuModels;
        }




    }
}
