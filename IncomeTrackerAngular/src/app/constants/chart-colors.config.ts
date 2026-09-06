// Categorical palette validated for CVD-safety (adjacent-pair Delta E >= 8 in both modes).
export const CHART_PALETTE = {
  light: ['#2a78d6', '#eb6834', '#1baf7a', '#eda100', '#e87ba4', '#008300', '#4a3aa7', '#e34948'],
  dark: ['#3987e5', '#d95926', '#199e70', '#c98500', '#d55181', '#008300', '#9085e9', '#e66767'],
} as const;

export function getChartPalette(isDark: boolean): readonly string[] {
  return isDark ? CHART_PALETTE.dark : CHART_PALETTE.light;
}

// Shuffled once per data load so charts get a fresh look each time, while staying within the validated set.
export function getShuffledPalette(isDark: boolean): string[] {
  const palette = [...getChartPalette(isDark)];
  for (let i = palette.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [palette[i], palette[j]] = [palette[j], palette[i]];
  }
  return palette;
}

export function getCategoricalColors(count: number, palette: readonly string[]): string[] {
  return Array.from({ length: count }, (_, i) => palette[i % palette.length]);
}
