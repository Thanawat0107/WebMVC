﻿using Microsoft.AspNetCore.Mvc;


namespace ProductWeb.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _roleService.GetAll();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDto roleDto)
        {
            var result = await _roleService.Add(roleDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string name)
        {
            var result = await _roleService.Find(name);
            var roleUpdate = new RoleUpdateDto { UpdateName = result.Name };

            return View(roleUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleUpdateDto roleUpdateDto)
        {
            var result = await _roleService.Update(roleUpdateDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string name)
        {
            var result = await _roleService.Delete(name);

            return RedirectToAction(nameof(Index));
        }

    }
}
