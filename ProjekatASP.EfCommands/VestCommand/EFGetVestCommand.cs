﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.CommandsProjekat.VestCommands;
using ProjekatASP.Application.DTO.KomentarDTO;
using ProjekatASP.Application.DTO.SlikaDTO1;
using ProjekatASP.Application.DTO.VestDTO;
using ProjekatASP.Application.ExceptionsProjekat;

namespace ProjekatASP.EfCommands.VestCommand
{
    public class EFGetVestCommand : EFBaseCommand, IGetVestCommand
    {
        public EFGetVestCommand(ProjekatASPContext context) : base(context)
        {
        }

        public VestKomentarGetDto Execute(int request)
        {
            var data = Context.Vests.Include(v => v.Slikas)
                .Include(k => k.Komentars)
                .SingleOrDefault(v => v.Id == request);



            if (data.Obrisano == true || data == null)
            {
                throw new DataNotFoundException("vest");
            }
        //dohvatiti samo aktivne komentare


            return new VestKomentarGetDto
            {
                Id = data.Id,
                Naslov = data.Naslov,
                Tekst = data.Tekst,
                TekstKomentara = data.Komentars.Select(k => new KomentarGetDto
                {
                    TekstKomentara = k.Komentar_Tekst,
                }).ToList(),
               /* KategorijaId = data.Kategorija.Id,
                NazivKategorije = data.Kategorija.Naziv,*/
                putanjaSlike = data.Slikas.Select(s => new SlikaGetDto
                  {
                      Putanja = s.Putanja
                  }).ToList()
              };
        }
    }
}