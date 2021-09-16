using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestoTexoIT.Application.Dtos;

namespace TestoTexoIT.Application.Services
{
    public class ReadFileService
    {
        AwardService _awardService;

        public ReadFileService(AwardService awardService)
        {
            _awardService = awardService;
        }

        public void ReadFile(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) != ".csv")
            {
                throw new Exception("Arquivo deve ser do tipo CSV.");
            }

            List<AwardListDto> awards = new List<AwardListDto>();

            using (var arqReader = new StreamReader(file.OpenReadStream()))
            {
                arqReader.ReadLine().Split(';');
                while (!arqReader.EndOfStream)
                {
                    var linha = arqReader.ReadLine().Split(';');

                    try
                    {
                        awards.Add(new AwardListDto()
                        {
                            Year = Convert.ToInt32(linha[0]),
                            Title = linha[1],
                            Studios = linha[2],
                            Producers = linha[3],
                            Winner = linha[4].ToLower().Trim() == "yes"
                        });
                    } 
                    catch(Exception ex)
                    {
                        throw new Exception("Arquivo em formato incorreto.");
                    }
                }
            }
            if (awards.Count > 0)
                _awardService.SaveAwardList(awards);
        }
    }
}
